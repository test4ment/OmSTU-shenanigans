from itertools import islice

def rotate(A):
	A.insert(0, A.pop())
	return A

def to5(a):
	'''C = []
	b = []
	for i in range(len(a)):
		b += [a[i]]
		if (i+1)%5==0:
			C += [b]
			b = []
	return C'''
	iterator = iter(a)
	return list(iter(lambda: list(islice(iterator, 5)), []))

def mirror(A):
	return list(map(list,map(reversed, A)))


def drotate(A):
	return rotate(rotate(A))


number = '4' #ввод проверки

with open ('input'+number+'.txt') as file:
	A = list(map(str.strip,file))
	B = []
	for i in A:
		B.append(list(map(int,i.split())))
#print(*B, sep = '\n')
'''
[0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0] #2
[1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0] # part
[0, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1, 0, 1, 0, 1] #2 * 2
#[1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0] #template
#[1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0]
[1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1]'''
## 1 4
## 2 3

parts = []
templates = []
N = B.pop(0)[0] #2

for _ in range(N):
	parts += [B.pop(0)]
for _ in range(2*N):
	templates += [(B.pop(0))]

templates2 = []
for i in templates:
	templates2 += [to5(i)]

n = [i for i in range(1, (2*N)+1)]

used = []
ita = 0
for a in parts:
	C = (to5(a)) 	#[[0, 0, 1, 1, 1]/\, [0, 0, 0, 1, 1]*, [1, 0, 1, 0, 1]\/, [0, 0, 1, 1, 0]x]
	#rotate(to5(a))
	temp = []
	case = 0
	badcase = []
	while True:
		for i in range(len(templates2)):
			if badcase:
				if badcase[0] == 1: case = 3
				elif badcase[0] == 3: case = 1
			if not(i in used) and (case != 1) and ((C[0] == templates2[i][0]) and (C[2] == templates2[i][2]) and ((C[1] == templates2[i][1]))):
				#temp += [n.pop(i)]
				#templates2.pop(i)
				temp += [i]
				used += [i]
				case = 1
				break
			if not(i in used) and (case != 1) and ((C[0] == list(reversed(templates2[i][0]))) and (C[2] == list(reversed(templates2[i][2]))) and ((C[1] == list(reversed(templates2[i][1]))))):
				#temp += [n.pop(i)]
				#templates2.pop(i)
				temp += [i]
				used += [i]
				case = 1
				break
			if not(i in used) and (case != 3) and ((C[0] == templates2[i][0]) and (C[2] == templates2[i][2]) and (C[3] == templates2[i][1])):
				#temp += [n.pop(i)]
				#templates2.pop(i)
				temp += [i]
				used += [i]
				case = 3
				break
			if not(i in used) and (case != 3) and ((C[0] == list(reversed(templates2[i][0]))) and (C[2] == list(reversed(templates2[i][2]))) and (C[3] == list(reversed(templates2[i][1])))):
				#temp += [n.pop(i)]
				#templates2.pop(i)
				temp += [i]
				used += [i]
				case = 3
				break
		else:
				if len(temp)==1:
					used.pop()
					temp = []
					badcase += [case]
					case = 0
					#print('pochita')
				C = rotate(C)
				#print('pochta')
			
		if len(temp) == 2: 
			badcase = []
			break
	print(sorted(temp)[0]+1,sorted(temp)[1]+1)

print()
for i in (open('output'+number+'.txt').readlines()): print(i.strip())
