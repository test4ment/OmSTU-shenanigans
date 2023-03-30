from math import inf

def Floyd(A):
	A = infinify(A)
	n = len(A)
	for k in range(n):
		for i in range(n):
			for j in range(n):
				if A[i][j] > A[i][k] + A[k][j]:
					A[i][j] = A[i][k] + A[k][j]
	#for i in range(n):
		#A[i][i] = ""
	return A

def infinify(A):
	for i in range(len(A)):
		for j in range(len(A)):
			if A[i][j] == 0: A[i][j] = inf
	return A
	
A = [
	[0, 10, 18, 8, 0, 0],
	[10, 0, 16, 9, 21, 0],
	[0, 16, 0, 0, 0, 15],
	[7, 9, 0, 0, 0, 12],
	[0, 0, 0, 0, 0, 23],
	[0, 0, 15, 0, 23, 0]
]

B = Floyd(A)

print(*Floyd(A), sep = "\n")
