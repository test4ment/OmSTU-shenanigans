def uninumber(numbers, excludingnums):
	for i in numbers:
		num = i
		counter = 0
		for j in excludingnums:
			if j < num:
				counter += 1
		num -= counter
		yield num

def prod(iterator):
	product = 1
	for i in iterator:
		product *= i
	return product

def unimoneygen(money, relation):
	lst = []
	for i in range(len(money)):
		lst += [money[i] * prod(relation[i:])]
	return sum(lst)

nums = [str(i) for i in range(1, 15)]
for num in nums:
	file = open("input/input" + num + ".txt").readlines()
	
	relations1 = [int(i) for i in file[0].split()[1:]] + [1]
	badluck1 = [int(i) for i in file[1].split()[1:]]
	relations2 = [int(i) for i in file[2].split()[1:]] + [1]
	badluck2 = [int(i) for i in file[3].split()[1:]]
	exchangefrom = [int(i) for i in file[4].split()]
	exchangefrom = list(uninumber(exchangefrom, badluck1))
	
	unimoney = unimoneygen(exchangefrom, relations1)
	
	stackedmoney = []
	for i in range(len(relations2)):
		stackedmoney += [unimoney // prod(relations2[i:])]
		unimoney = unimoney % prod(relations2[i:])
	
	finalmoney = []
	for i in stackedmoney:
		pile = i
		for j in badluck2:
			if j <= i: pile += 1
		finalmoney += [pile]
	
	print(*finalmoney, "|", open("output/output" + num + ".txt").readline())
