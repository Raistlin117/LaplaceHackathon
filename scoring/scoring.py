import requests
import json

from distance import *

# Read data for scoring
with open('data.json', 'r') as file:
    json_data = json.load(file)

properties = json_data['data']

# API KEY
api_key = ''

for p in properties[:1]:
    id = p['id']
    name = p['name']
    longitude = p['longitude']
    latitude = p['latitude']

    print(f'Getting Features for {name}')
    
    # Get scoring features
    distance2metro_station = find_closest_facility(api_key, longitude, latitude, 'metro station')
    print(f'Distance to Metro: {distance2metro_station}')
    distance2hospital = find_closest_facility(api_key, longitude, latitude, 'hospital')
    print(f'Distance to Hospital: {distance2hospital}')
    distance2park = find_closest_facility(api_key, longitude, latitude, 'park')
    print(f'Distance to Park: {distance2park}')


    
