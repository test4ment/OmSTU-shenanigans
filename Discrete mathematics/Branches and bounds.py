from math import inf

def minC(T, col):
	return min([i[col] for i in T])

def compose(tuples): # Объединяет кусочки путей
	while True: # Пример: [(2, 5), (5, 1), (3, 2)] -> [(3, 2, 5, 1)]
		breaker = False
		for i in range(len(tuples)):
			for j in range(len(tuples)):
				if j == i: continue
				if tuples[j][-1] == tuples[i][0]:
					a, b = tuples[i], tuples[j]
					tuples.remove(a), tuples.remove(b)
					tuples += [b + tuple(a[1:])]
					breaker = True
					break
			if breaker: break
		else:
			break
	return tuples

def brancher(A):
	num_row = [i for i in range(len(A))]
	num_column = [i for i in range(len(A))]
	way = 0
	letterway = []
	while len(A) > 2:
		for i in range(len(A)):
			a = min(A[i])
			way += a
			A[i] = [i - a for i in A[i]]
		for i in range(len(A)):
			a = minC(A, i)
			way += a
			for j in range(len(A)):
				A[j][i] -= a
		#way = 73
		list_of_zeroes = []
		for i in range(len(A)):
			for j in range(len(A)):
				if A[i][j] == 0:
					A[i][j] = inf
					A[i][j] = (0, min(A[i]) + minC(A, j)) #Для понимания
					list_of_zeroes += [(i, j, A[i][j][1])]
					A[i][j] = 0	
		#print(*A, sep="\n", end = "\n\n")
		nexta, nextb, fine = sorted(list_of_zeroes, key = lambda x: x[2])[-1] #nexta, nextb даны в локальных координатах
		letterway += [(num_row[nexta], num_column[nextb])]
		letterway = compose(letterway)
		infa, infb = num_row.index(letterway[-1][-1]), num_column.index(letterway[-1][0])
		A[infa][infb] = inf
		num_row.pop(nexta)
		num_column.pop(nextb)
		for i in range(len(A)):
			A[i].pop(nextb)
		A.pop(nexta)
	for i in range(len(A)):
		for j in range(len(A)):
			if A[i][j] == 0:
				letterway += [(num_row[i], num_column[j])]
				#print(letterway)
	return way, tuple(i+1 for i in compose(letterway)[0])

A = [[inf, 77, 88, 8, 7],
		 [6, inf, 45, 16, 31],
		 [1, 7, inf, 14, 11],
		 [88, 16, 65, inf, 8],
		 [55, 77, 45, 11, inf]] #74

B = [[inf, 1, 1],
		 [1, inf, 1],
		 [1, 1, inf]] #3

C = [[inf, 8, inf, inf, inf],
		 [inf, inf, 3, inf, inf],
		 [inf, inf, inf, 2, inf],
		 [inf, inf, inf, inf, 1],
		 [1, inf, inf, inf, inf]] #15

print(brancher(A))
