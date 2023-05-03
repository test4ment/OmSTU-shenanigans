numbers = ["0" + str(i) for i in range(1, 10)] + [str(i) for i in range(10, 21)]
for num in numbers:
	file = (open("/Паук и муха/input_s1_" + num + ".txt").readlines())
	a, b, c, Sx, Sy, Sz, Fx, Fy, Fz = int(file[0].split()[0]), int(file[0].split()[1]), int(file[0].split()[2]), int(file[1].split()[0]), int(file[1].split()[1]), int(file[1].split()[2]), int(file[2].split()[0]), int(file[2].split()[1]), int(file[2].split()[2])
	del file

	locS, locF = "0", "0"
	
	def dist(tup1, tup2):
		from math import sqrt
		return sqrt((tup1[0] - tup2[0])**2 + (tup1[1] - tup2[1])**2 + (tup1[2] - tup2[2])**2)
	
	if Sy == b: locS = "1"
	elif Sz == c: locS = "2"
	elif Sy == 0: locS = "3"
	elif Sz == 0: locS = "4"
	elif Sx == 0: locS = "S1"
	elif Sx == a: locS = "S2"
	
	if Fy == b: locF = "1"
	elif Fz == c: locF = "2"
	elif Fy == 0: locF = "3"
	elif Fz == 0: locF = "4"
	elif Fx == 0: locF = "S1"
	elif Fx == a: locF = "S2"
	
	one_in_delta = 10 # Точность вычислений
	
	Arange = [i / one_in_delta for i in range(0, a * one_in_delta + 1)]
	Brange = [i / one_in_delta for i in range(0, b * one_in_delta + 1)]
	Crange = [i / one_in_delta for i in range(0, c * one_in_delta + 1)]
	
	if locS == locF: ls += [((Sx - Fx)**2 + (Sy - Fy)**2 + (Sz - Fz)**2)**0.5]
	else:
		if sorted([Sx, Fx]) == [0, a] or sorted([Sy, Fy]) == [0, b] or sorted([Sx, Fx]) == [0, c]:
			se = set()
			if Sx == 0 or Sx == a:
				for i in Brange:
					se.add((Sx, i, c))
					se.add((Sx, i, 0))
				for i in Crange:
					se.add((Sx, b, i))
					se.add((Sx, 0, i))
			elif Sy == 0 or Sy == b:
				for i in Arange:
					se.add((i, Sy, c))
					se.add((i, Sy, 0))
				for i in Crange:
					se.add((a, Sy, i))
					se.add((0, Sy, i))
			elif Sz == 0 or Sz == c:
				for i in Arange:
					se.add((i, b, Sz))
					se.add((i, 0, Sz))
				for i in Brange:
					se.add((a, i, Sz))
					se.add((0, i, Sz))
	
			fe = set()
			if Fx == 0 or Fx == a:
				for i in Brange:
					fe.add((Fx, i, c))
					fe.add((Fx, i, 0))
				for i in Crange:
					fe.add((Fx, b, i))
					fe.add((Fx, 0, i))
			elif Fy == 0 or Fy == b:
				for i in Arange:
					fe.add((i, Fy, c))
					fe.add((i, Fy, 0))
				for i in Crange:
					fe.add((a, Fy, i))
					fe.add((0, Fy, i))
			elif Fz == 0 or Fz == c:
				for i in Arange:
					fe.add((i, b, Fz))
					fe.add((i, 0, Fz))
				for i in Brange:
					fe.add((0, i, Fz))
					fe.add((a, i, Fz))
	
			ls = []
			for i in se:
				for j in fe:
					ls += [dist(i, (Sx, Sy, Sz)) + dist(j, (Fx, Fy, Fz)) + dist(i, j)]
		else:
			se = set()
			if Sx == 0 or Sx == a:
				for i in Brange:
					se.add((Sx, i, c))
					se.add((Sx, i, 0))
				for i in Crange:
					se.add((Sx, b, i))
					se.add((Sx, 0, i))
			elif Sy == 0 or Sy == b:
				for i in Arange:
					se.add((i, Sy, c))
					se.add((i, Sy, 0))
				for i in Crange:
					se.add((a, Sy, i))
					se.add((0, Sy, i))
			elif Sz == 0 or Sz == c:
				for i in Arange:
					se.add((i, b, Sz))
					se.add((i, 0, Sz))
				for i in Brange:
					se.add((a, i, Sz))
					se.add((0, i, Sz))
	
			fe = set()
			if Fx == 0 or Fx == a:
				for i in Brange:
					fe.add((Fx, i, c))
					fe.add((Fx, i, 0))
				for i in Crange:
					fe.add((Fx, b, i))
					fe.add((Fx, 0, i))
			elif Fy == 0 or Fy == b:
				for i in Arange:
					fe.add((i, Fy, c))
					fe.add((i, Fy, 0))
				for i in Crange:
					fe.add((a, Fy, i))
					fe.add((0, Fy, i))
			elif Fz == 0 or Fz == c:
				for i in Arange:
					fe.add((i, b, Fz))
					fe.add((i, 0, Fz))
				for i in Brange:
					fe.add((0, i, Fz))
					fe.add((a, i, Fz))
	
			ls = []
			inter = fe.intersection(se)
			for i in inter:
				ls += [dist((Sx, Sy, Sz), i) + dist(i, (Fx, Fy, Fz))]
	out = open("/Паук и муха/output_s1_" + num + ".txt").readlines()
	print(f"{min(ls):.3f} {out}")
	ls.clear()
