import requests
from utils import get_distance_km

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