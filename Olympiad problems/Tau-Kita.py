def decipher_word(word):
	s = ""
	i, a = 0, 0
	while i < len(word):
		s += word[len(word)//2 + a]
		if i % 2 == 0:
			a += 1
		i += 1
		a = -a
	return s

def decipher_phrase(phrase):
	L = []
	phraseL = phrase.split()
	i, a = 0, 0
	while i < len(phraseL):
		L += [decipher_word(phraseL[len(phraseL)//2 + a])]
		if i % 2 == 0:
			a += 1
		i += 1
		a = -a
	return L

def main():
	for el in range(1,10):
			with open(f'example/input_s1_0{el}.txt') as file, open(f'example/output_s1_0{el}.txt') as file_output:
				line = file.readlines()[0]
				result = file_output.readlines()[0]
				if decipher_phrase(line) == result.split():
					print(True)
				else:
					print(False)
					
if __name__ ==  '__main__':
	 main()
	
