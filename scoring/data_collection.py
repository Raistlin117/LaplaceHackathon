import requests
from geopy.distance import geodesic
from typing import Tuple


def find_closest_facility(api_key, longitude, latitude, facility):
    url = 'https://search-maps.yandex.ru/v1/'

    params = {
        'apikey': api_key,
        'text': facility,
        'lang': 'en_US',
        'type': 'biz',
        'll': f'{longitude},{latitude}',
        'rspn': '0',
        'results': '1'
    }

    response = requests.get(url, params=params)

    if response.status_code == 200:
        data = response.json()
        features = data.get('features', [])
        if features:
            facility = features[0]
            coordinates = facility['geometry']['coordinates']

            coord1 = (longitude, latitude)  # property
            coord2 = tuple(coordinates)  # facility

            distance = get_distance_km(coord1, coord2)
            return distance
    else:
        print(f"Error: {response.status_code}")
        return None
    
def get_air_polution(api_key, longitude, latitude):
    url = f'http://api.openweathermap.org/data/2.5/air_pollution?lat={latitude}&lon={longitude}&appid={api_key}'
    response = requests.get(url)

    if response.status_code == 200:
        data = response.json()
        pollution_metrics = data['list'][0]['components']
        return pollution_metrics
    else:
        print(f"Error: {response.status_code}")
        return None

def get_distance_km(coord1: Tuple[float, float], coord2: Tuple[float, float]) -> float:
    distance_km = geodesic(coord1, coord2).kilometers
    return distance_km


