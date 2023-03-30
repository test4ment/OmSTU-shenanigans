from math import inf

def FordBellman(A, start):
	start -= 1
	A = infinify(A)
	n = len(A)
	lmbd = [inf for i in range(n)]
	lmbd[start] = 0
	for i in range(n):
		temp = []
		for j in range(n):
			for k in range(n):
				temp += [lmbd[j] + A[j][k]]
		for j in range(n):
			lmbd[j] = min([temp[k] for k in range(j, len(temp), n)] + [lmbd[j]])
	return lmbd
		
def infinify(A):
	for i in range(len(A)):
		for j in range(len(A)):
			if A[i][j] == 0: A[i][j] = inf
	return A

A = [
	[0, 7, 9, 0, 11, 0],
	[0, 0, 6, 6, 0, 0],
	[0, 0, 0, 5, 6, 0],
	[0, 0, 0, 0, 0, 0],
	[0, 4, 0, 0, 0, 8],
	[0, 0, 0, 7, 0, 0]
]

print(FordBellman(A, 1))
