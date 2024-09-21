from geopy.distance import geodesic
from typing import Tuple

def get_distance_km(coord1: Tuple[float, float], coord2: Tuple[float, float]) -> float:
    """
    Calculate the geodesic distance between two geographical coordinates.
    """
    distance_km = geodesic(coord1, coord2).kilometers
    return distance_km

