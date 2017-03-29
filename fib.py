#!/usr/bin/env python
#
# 1,2,3,5,8,...
#

def fib(a=0,b=1):
 for i in range(10):
  yield a+b
  a,b=b,a+b
  
if __name__ == '__main__':
 print [num for num in fib()]
 
