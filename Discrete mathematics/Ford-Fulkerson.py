from math import inf

def breadthFirst(A, s, t, parent): # Поиск в ширину
		visited = [False] * (len(A))
		queue = []
		queue += [s]
		visited[s] = True
		
		while queue:
				u = queue.pop(0)
				for ind, val in enumerate(A[u]):
						if visited[ind] == False and val > 0:
								queue.append(ind)
								visited[ind] = True
								parent[ind] = u

		return True if visited[t] else False

def ford_fulkerson(A, source, sink):
		parent = [-1] * len(A)
		max_flow = 0
		while breadthFirst(A, source, sink, parent):
				path_flow = inf
				s = sink
				while(s != source):
						path_flow = min(path_flow, A[parent[s]][s])
						s = parent[s]
				max_flow += path_flow
				v = sink
				while(v != source):
						u = parent[v]
						A[u][v] -= path_flow
						A[v][u] += path_flow
						v = parent[v]
		return max_flow

    
        
graph = [[0, 8, 4, 5, 3, 1],
         [0, 0, 7, 0, 9, 0],
         [1, 0, 0, 0, 7, 2],
         [0, 0, 6, 0, 0, 5],
         [0, 2, 8, 4, 0, 0],
         [0, 0, 4, 0, 2, 0]]


source = 0
sink = 5

print(ford_fulkerson(graph, source, sink))
