# MergeSort Algorithm
def ord(lst):
 for a,alpha in enumerate(lst):
  for b,beta in enumerate(lst):
   if a>b and alpha<beta:
    lst[a],lst[b]=lst[b],lst[a]
 return list(set(lst))

if __name__ == '__main__':
 lst=[3,1,2,0]
 mid=(len(lst)/2)
 print ord(ord(lst[:mid])+ord(lst[mid:]))
