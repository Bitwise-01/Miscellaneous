# Date: 04/13/2018
# Author: Mohamed Sheikh
# Description: Travelling salesman problem

class Location(object):
 def __init__(self, name, dist):
  self.name = name.title()
  self.dist = dist

class Person(object):
 def __init__(self, data):
  self.places = [Location(name, data[name]) for name in data]

 def solution(self):
  here = None 
  solution = []

  while self.places:
   here = self.places[0] if not here else self.getNextLocation(here)
   if here:
    data = '{} --> {}'.format(here.name, here.dist)
    solution.append(data)
  return solution
  
 def getNextLocation(self, here):
  lastPlace = None 
  for p1 in self.places:
   for p2 in self.places:
    if any([p1 == here, p2 == here]):continue
    newPlace = self.newPlace(here, p1, p2)
    if not lastPlace:
     lastPlace = newPlace
    else:
     lastPlace = self.newPlace(here, newPlace, lastPlace)

  del self.places[self.places.index(here)]
  return lastPlace
  
 def newPlace(self, here, p1, p2):
  return p1 if abs(here.dist - float(p1.dist)) <= abs(here.dist - float(p2.dist)) else p2

data = {
 'a': 1,
 'b': 2,
 'c': 3,
 'd': 4
}

n = Person(data)
print n.solution()