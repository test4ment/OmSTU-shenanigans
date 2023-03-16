def Deikstra(A, start, end):
	start -= 1
	end -= 1
	i = 0
	way = []
	way += [start] #1
	noWay = []
	distance = 0
	next = minNz(A[way[-1]])
	nextN = A[way[-1]].index(next)
	way += [nextN] #1, 2
	distance = next
	while True:
		#print(next, nextN)
		#print(way)
		next = minNz(A[way[-1]])
		nextN = A[way[-1]].index(next) 
		if nextN in way:
			if nextN == way[-2]: #занулять столбец пройденной точки
				distance -= A[way[-2]][way[-1]]
				A = nullC(A, way[-1])
				way = way[:-1]
				continue
			elif minC(A, nextN) < next:
				next = minC(A, nextN)
				A[way[-1]][nextN] = next
		way += [nextN]
		distance += next
		if nextN == end:
			return distance, way

def minC(A, i):
	import numpy as np
	return min(filter(lambda x: x>0, (np.array(A).transpose()[i])))

def minNz(list):
	return min(filter(lambda x: x>0, list))

def nullC(l, i):
	for j in range(len(l)):
		l[j][i] = 0
	return l

A = [
		[0, 32, 95, 75, 57, 0, 0, 0], #1
		[0, 0, 5, 0, 23, 0, 0, 16], #2
		[0, 0, 0, 18, 0, 6, 0, 0], #3
		[0, 0, 0, 0, 24, 9, 0, 0], #4
		[0, 0, 0, 0, 0, 0, 20, 94], #5
		[0, 0, 0, 0, 11, 0, 7, 0], #6
		[0, 0, 0, 0, 0, 0, 0, 81], #7
		[0, 0, 0, 0, 0, 0, 0, 0]  #8
	] #1  2  3  4  5  6  7  8

B = [
		[0, 7, 0, 0, 9, 2, 5], #1
		[7, 0, 5, 4, 8, 2, 0], #2
		[0, 5, 0, 2, 9, 0, 1], #3
		[0, 4, 2, 0, 3, 0, 8], #4
		[9, 8, 9, 3, 0, 3, 5], #5
		[2, 2, 0, 0, 3, 0, 0], #6
		[5, 0, 1, 8, 5, 0, 0], #7
]

#print(Deikstra(A, 2, 7)) #18
print(Deikstra(B, 1, 7)) #5
