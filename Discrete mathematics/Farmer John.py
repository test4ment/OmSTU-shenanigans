def kruskal(graph, verticiesN):
	result = []
	i, e = 0, 0
	graph = sorted(graph, key=lambda item: item[2])
	global parent
	parent = []
	rank = []
	for node in range(verticiesN):
			parent.append(node)
			rank.append(0)
	while e < verticiesN - 1:
			u, v, w = graph[i]
			i = i + 1
			x = search(parent, u)
			y = search(parent, v)
			if x != y:
					e = e + 1
					result.append((u, v, w))
					apply_union(parent, rank, x, y)
	return kruskal_len(result), result

def search(parent, i):
	if parent[i] == i:
			return i
	return search(parent, parent[i])

def apply_union(parent, rank, x, y):
	xroot = search(parent, x)
	yroot = search(parent, y)
	if rank[xroot] < rank[yroot]:
			parent[xroot] = yroot
	elif rank[xroot] > rank[yroot]:
			parent[yroot] = xroot
	else:
			parent[yroot] = xroot
			rank[xroot] += 1

def kruskal_len(result) -> int:
	return sum([i[2] for i in result])

# W, P = map(int, input().split()) #Генерация ручками
# for i in range(P):
# 	pipe_list = tuple(map(int, input().split()))

W, P = 11, 20
pipe_list = [(1, 2, 4), (1, 8, 8), (1, 9, 7), (2, 3, 5), (2, 8, 4), (3, 4, 3), (3, 8, 9), (4, 5, 5), (4, 7, 6), (4, 8, 7), (5, 6, 9), (5, 7, 4), (6, 7, 6), (6, 11, 13), (7, 8, 1), (7, 11, 4), (8, 9, 1), (8, 10, 3), (9, 10, 2), (10, 11, 14)]

pipe_list = [(i[0] - 1, i[1] - 1, i[2]) for i in pipe_list] # Перенумеруем вершины комьютеру понятно

least = kruskal(pipe_list, W) # Крускал найдёт минимальное остовное дерево

lens = [] # Список всех длин
for i in least[1]:
	new_pipe_list = pipe_list[:]
	new_pipe_list.remove(i) # По одному удаляем ребра, смотрим что получается
	lens += [kruskal(new_pipe_list, W)[0]]

lens = [i for i in lens if i != least[0]] # Если существует несколько минимальных остовных деревьев, не рассматриваем ни одно из них
print(min(lens))
