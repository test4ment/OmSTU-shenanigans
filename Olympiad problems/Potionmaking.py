nums = [str(i) for i in range(1, 11)]
for num in nums:
	file = open("input/input" + num + ".txt").readlines()
	act = []
	for i in range(len(file)):
		file[i] = file[i].strip()
		act = file[i].split()
		string = ""
		
		for j in range(len(act)):
			if act[j].isdigit():
				act[j] = file[int(act[j]) - 1]
		
		word = act.pop(0)
		
		if word == "MIX":
			string = "MX" + "".join(act) + "XM"
		if word == "WATER":
			string = "WT" + "".join(act) + "TW"
		if word == "DUST":
			string = "DT" + "".join(act) + "TD"
		if word == "FIRE":
			string = "FR" + "".join(act) + "RF"

		file[i] = string
	print(open("output/output" + num + ".txt").readline() == file[-1])
