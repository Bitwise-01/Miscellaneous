# Python: 2.7
# Tree sort algorithm

from time import time
from random import randint 

class Node(object):
 def __init__(self, node):
  self.number = node # can store a node object or an int
  self.leftNode = None
  self.rightNode = None
  self.nodes = {'left': [], 'right': []}
  
 def add(self, newNode, node=None):
  if not node:
   # prevent repeats
   number = self.number if type(self.number) == int else self.number.number
   if newNode.number == number: # get number from node object
    return

   if newNode.number < number:
    if not self.leftNode:self.leftNode = newNode 
    else:self.add(newNode, self.leftNode)

   elif newNode.number > number:
    if not self.rightNode:self.rightNode = newNode
    else:self.add(newNode, self.rightNode)
   else:pass

  else:
   # prevent repeats
   if newNode.number == node.number:
    return

   if newNode.number < node.number:
    if not node.leftNode:node.leftNode = newNode
    else:node.add(newNode, node.leftNode)
   
   elif newNode.number > node.number:
    if not node.rightNode:node.rightNode = newNode
    else:node.add(newNode, newNode.leftNode)
   else:pass

 def retrieveLeftNodes(self, node=None):
  if not node:
   if self.leftNode:
    self.retrieveLeftNodes(self.leftNode)

  else:
   if node.leftNode:
    self.retrieveLeftNodes(node.leftNode)

   self.nodes['left'].append(node.number)
   if node.rightNode:
    self.retrieveLeftNodes(node.rightNode)
   
 def retrieveRightNodes(self, node=None):
  if not node:
   if self.rightNode:
    self.retrieveRightNodes(self.rightNode)

  else:
   if node.leftNode:
    self.retrieveRightNodes(node.leftNode)

   self.nodes['right'].append(node.number)
   if node.rightNode:
    self.retrieveRightNodes(node.rightNode)


class TreeSort(object):
 def __init__(self, nlist): 
  self.numbers = [Node(_) for _ in nlist]
  self.root = self.numbers[len(self.numbers)/2]

 def sort(self):
  started = time()
  self.structNodes()
  self.root.retrieveLeftNodes()
  self.root.retrieveRightNodes()

  self.root.nodes['left'].append(self.root.number)
  return [self.root.nodes['left'] + self.root.nodes['right'], (time() - started)]

 def structNodes(self):
  # add nodes to the root node 
  [self.root.add(_) for _ in self.numbers]


if __name__ == '__main__':
 nlist = [randint(0, 10) for _ in range(10)]

 n = TreeSort(nlist).sort()
 print 'Input: {}\nOutput: {}\nTime: {}'.format(nlist, n[0], n[1])