A = [
	[0, 1, 0, 0, 1], 
	[1, 0, 0, 1, 1], 
	[0, 0, 0, 0, 0], 
	[0, 1, 0, 0, 1], 
	[1, 1, 0, 1, 0], 
]

def cohesion(A):
	n = len(A)
	vertices = [i for i in range(n)]
	components = []
	while vertices:
		v = vertices[0]
		if somewhereIn(v, components):
			for i in range(n):
				if A[v][i] == 1:
					components = insert(v, i, components)
			vertices.pop(0)
		else:
			components += [[v]]
			for i in range(n):
				if A[v][i] == 1:
					components = insert(v, i, components)
			vertices.pop(0)

	return uniqify(components)
			
def somewhereIn(object, listoflist):
	try:
		for i in range(len(listoflist)):
			if object in listoflist[i]:
				return True
		else:
			return False
	except:
		return False

def insert(object, object_insert, listoflist):
	for i in range(len(listoflist)):
		if object in listoflist[i]:
			listoflist[i] += [object_insert]
			return listoflist
	else:
		return False

def uniqify(listoflist):
	uni = []
	for i in listoflist:
		uni += [set(i)]
	return list(map(list, uni))

print(list(map(list, [map(lambda x: x + 1, i) for i in cohesion(A)])))
