def Kruskal(A):
	B = A.copy()
	C = []
	c = []
	B.sort(key = lambda tup: tup[2])
	while B:
		if not SomewhereIn(B[0][0], C) and not SomewhereIn(B[0][1], C):
			C.append([B[0][0], B[0][1]])
			c += [B[0][2]]
			#print(C, c)
		elif SomewhereIn(B[0][0], C) and not SomewhereIn(B[0][1], C):
			for i in range(len(C)):
				if B[0][0] in C[i]:
					C[i] += [B[0][1]]
					c[i] += B[0][2]
					#print(C,c)
					break
		elif not SomewhereIn(B[0][0], C) and SomewhereIn(B[0][1], C):
			for i in range(len(C)):
				if B[0][1] in C[i]:
					C[i] += [B[0][0]]
					c[i] += B[0][2]
					#print(C,c)
					break
		else:
			#print(B)
			if len(C) > 1:
				#print(C,c)
				d, e = -1, -1
				for i in range(len(C)):
					if B[0][0] in C[i]:
						d = i
					if B[0][1] in C[i]:
						e = i
				if d != e:
					C[d] = C[d] + C[e]
					c[d] = c[d] + c[e]
					c[d] += B[0][2]
					del C[e]
					del c[e]
		del B[0]
		#print(B)
	return c

def SomewhereIn(obj, place):
	for i in place:
		if obj in i:
			return True
	else: return False
	
def Prima(A):
  B = A.copy()
  C = []
  c = 0
  l = []
  for i in B:
    l += list(i[0] + i[1])
  l1=list(set(l))
  m = 2
  B.sort(key = lambda tup: tup[2])
  #print(B)
  C += B[0][0]
  C += B[0][1]
  c += B[0][2]
  #print(B[0][0], B[0][1], B[0][2])
  del B[0]
  while m<len(l1):
    for j in range(len(B)):
      if (B[j][0] in C and not B[j][1] in C) or(B[j][1] in C and not B[j][0] in C):
        #print(B[j][0], B[j][1], B[j][2])
        C+=B[j][1]
        C+=B[j][0]
        c+=B[j][2]
        m+=1
        del B[j]
        break
  return c

A = [("A", "B", 1), ("B", "C", 1), ("C", "D", 1), ("A", "D", 1)]
D = [("A", "B", 2), ("B", "C", 2), ("A", "C", 2), ("B", "E", 2), ("A", "E", 7), ("C", "E", 5), ("B", "D", 9), ("D", "E", 10), ("D", "G", 2), ("E", "G", 9), ("G", "H", 17), ("D", "H", 16), ("D", "F", 5), ("F", "H", 17)] #38
E = [("A", "B", 4), ("A", "E", 6), ("A", "D", 3), ("A", "F", 1), ("B", "C", 2), ("B", "G", 1), ("B", "E", 7), ("B", "D", 3), ("B", "F", 6), ("C", "G", 2), ("C", "E", 4), ("D", "E", 1), ("D", "F", 5), ("D", "G", 3), ("E", "F", 3), ("E", "G", 6), ("F", "G", 7)] #11

for i in [A, D, E]:
	print(Prima(i), Kruskal(i))
