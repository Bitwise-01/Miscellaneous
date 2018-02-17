# Python: 2.7
# Merge sort algorithm

from time import time
from random import randint

class MergeSort(object):
 def __init__(self, nlist, repeat=True):
  self.list = nlist
  self.repeat = repeat
  
 def bubbleSort(self, nlist):
  for a, alpha in enumerate(nlist):
   for b, beta in enumerate(nlist):
    if a>b and alpha<beta:
     nlist[a], nlist[b] = nlist[b], nlist[a]
  return nlist if self.repeat else self.removeRepeats(nlist) 

 def removeRepeats(self, nlist):
  for a, alpha in enumerate(nlist):
   for b, beta in enumerate(nlist):
    if a != b and alpha == beta:
     nlist.pop(a)
  return nlist

 @property
 def sort(self):
  started = time()
  mid = len(self.list)/2
  beta = self.bubbleSort(self.list[mid:])
  alpha = self.bubbleSort(self.list[:mid])
  return [self.bubbleSort(alpha + beta), time() - started]

if __name__ == '__main__':
 lst = [randint(0, 20) for _ in xrange(20)]

 n = MergeSort(lst, repeat=False).sort
 print 'Input: {}\nOutput: {}\nTime: {}'.format(lst, n[0], n[1])
