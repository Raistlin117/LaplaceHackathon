import requests
import json
import pandas as pd
from sklearn.preprocessing import MinMaxScaler

from data_collection import *

# Read properties coordinates for scoring
with open('data.json', 'r') as file:
    json_data = json.load(file)

properties = json_data['data']

# Yandex Maps API KEY
yandex_api_key = '0f8bd640-4edb-40a0-a86c-9c2713622e13'
# Open Weather API KEY
oweather_api_key = '35f7f231c2e8e7942cef3aa53104a063'


# Collect Data
property_data = []

for p in properties:
    id = p['id']
    name = p['name']
    longitude = p['longitude']
    latitude = p['latitude']

    print(f'Getting Features for {name}')
    
    # Get scoring features
    # Maps
    distance2metro_station = find_closest_facility(yandex_api_key, longitude, latitude, 'metro station')
    distance2hospital = find_closest_facility(yandex_api_key, longitude, latitude, 'hospital')
    distance2park = find_closest_facility(yandex_api_key, longitude, latitude, 'park')
    distance2school = find_closest_facility(yandex_api_key, longitude, latitude, 'school')
    distance2kindergarten = find_closest_facility(yandex_api_key, longitude, latitude, 'kindergarten')
    distance2shopping_mall = find_closest_facility(yandex_api_key, longitude, latitude, 'shopping mall')

    # Air Pollution
    pollution_data = get_air_polution(oweather_api_key, longitude, latitude)
    
    # Get a dataframe
    property_data.append({
        'property_id': id,
        'property_name': name,
        'distance2metro_station': distance2metro_station,
        'distance2hospital': distance2hospital,
        'distance2park': distance2park,
        'distance2school': distance2school,
        'distance2kindergarten': distance2kindergarten,
        'distance2shopping_mall': distance2shopping_mall,
        'pm2_5': pollution_data['pm2_5'],
        'pm10': pollution_data['pm10'],
        'no2': pollution_data['no2'],
        'so2': pollution_data['so2'],
        'o3': pollution_data['o3']
    })

# Create a Pandas DataFrame from the collected data
df_properties = pd.DataFrame(property_data)

# Define weights for distance-related and pollution-related features separately
distance_weights = {
    'distance2metro_station': 0.15,
    'distance2hospital': 0.10,
    'distance2park': 0.10,
    'distance2school': 0.10,
    'distance2kindergarten': 0.05,
    'distance2shopping_mall': 0.10
}

pollution_weights = {
    'pm2_5': 0.15,
    'pm10': 0.10,
    'no2': 0.05,
    'so2': 0.05,
    'o3': 0.05
}

scaler = MinMaxScaler()

# Calculate distance score
distance_data = df_properties[list(distance_weights.keys())].copy()

# Inverse the distances to give higher scores to closer distances
for col in distance_data.columns:
    distance_data[col] = 1 / distance_data[col]

# Normalize distance features
distance_data_normalized = pd.DataFrame(scaler.fit_transform(distance_data), columns=distance_data.columns)

# Calculate distance score by applying weights
distance_data_normalized['distance_score'] = sum(distance_data_normalized[col] * weight for col, weight in distance_weights.items())

# Calculate pollution score
pollution_data = df_properties[list(pollution_weights.keys())].copy()

# Inverse the pollution values to give higher scores to lower pollution levels
for col in pollution_data.columns:
    pollution_data[col] = 1 / pollution_data[col]

# Normalize pollution features
pollution_data_normalized = pd.DataFrame(scaler.fit_transform(pollution_data), columns=pollution_data.columns)

# Calculate pollution score by applying weights
pollution_data_normalized['pollution_score'] = sum(pollution_data_normalized[col] * weight for col, weight in pollution_weights.items())

# Combine distance and pollution scores with the new weights
df_properties['distance_score'] = distance_data_normalized['distance_score']
df_properties['pollution_score'] = pollution_data_normalized['pollution_score']
df_properties['final_score'] = (df_properties['distance_score'] * 0.80) + (df_properties['pollution_score'] * 0.20)

# Save Data
df_properties.to_json('data_with_score.json', orient='records', indent=4)

