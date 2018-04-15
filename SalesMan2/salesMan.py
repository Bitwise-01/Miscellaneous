# Date: 04/14/2018
# Author: Mohamed Sheikh
# Description: Another attempt to solving the TSP

class Point(object):
 def __init__(self, name, x, y):
  self.coord = (x, y)
  self.name = name 

class SalesMan(object):
 def __init__(self, data):
  self.data = self.parseData(data)
  self.initial = Point('Initial', data['Initial'][0], data['Initial'][1])

 def parseData(self, data):
  return [Point(_, data[_][0], data[_][1]) for _ in data if _ != 'Initial' if data[_] != data['Initial']]

 def run(self):
  here = None 
  solution = []

  while self.data:
   here = self.nextPoint(self.initial) if not here else self.nextPoint(here)
   if here:
    data = '{} --> {}'.format(here.name, here.coord)
    solution.append(data)
  print solution

 def nextPoint(self, here):
  closest = None 
  for p1 in self.data:
   for p2 in self.data:
    if any([p1 == here, p2 == here]):continue
    if not closest:
     closest = p1 
     
    _closest = p1 if self.distance(here.coord, p1.coord) < self.distance(here.coord, p2.coord) else p2
    closest = _closest if self.distance(here.coord, _closest.coord) < self.distance(here.coord, closest.coord) else closest

  if here in self.data:del self.data[self.data.index(here)]
  return closest
     
 def distance(self, c1, c2):
  x1, y1 = c1[0], c1[1] 
  x2, y2 = c2[0], c2[1]
  return self.sqrRoot(self.sqr(x2 - x1) + self.sqr(y2 - y1)) 

 def sqr(self, num):
  return num ** 2

 def sqrRoot(self, num):
  return num ** 0.5

data = {
    'Initial': (0,0), # starting point
    'A': (-3, 0),
    'B': (-2, -12),
    'C': (-1, -8),
    'D': (-1, 0),
    'E': (2, -11),
    'F': (-2, 0)   
}

n = SalesMan(data)
n.run()


