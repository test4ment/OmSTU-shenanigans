def worker(ID):
    a = lis[:]
    ret = []
    i = 0
    while a:
        if a[0][0] == ID:
            ret += [a[0][1]]
            a.pop(0)
        elif a[0][0] in ret:
            ret += [a[0][1]]
            a.pop(0)
        else:
            i += 1
            if i == 10001:
                break
            a.append(a.pop(0))
    return ret
  
for index in range(1, 17):
  with open (f"XXX_Company/input_s1_{index}.txt") as file_input, open (f"XXX_Company/output_s1_{index}.txt") as file_output:
    a = list(map(str.strip, file_input.readlines()))
    out = list(map(str.strip, file_output.readlines()))
    dic= {}
    lis = []

    for i in range(0, len(a), 2):
        if a[i] == "END": break
        lis += [(a[i][:4], a[i + 1][:4])]
        if len(a[i]) != 4:
            dic[a[i][:4]] = a[i][5:]
        if len(a[i + 1]) != 4:
            dic[a[i + 1][:4]] = a[i + 1][5:]

    name = a[-1]
    resultd = {}
    if name.isdigit():
        for i in sorted(worker(name)):
            try:
              #print(i, dic[i])
              resultd[i] = dic[i]  
            except:
              #print(i, "Unknown Name")
              resultd[i] = "Unknown Name"
    else:
        for u, v in dic.items():
            if v == name:
                name = u
                break
        for i in sorted(worker(name)):
            try:
              #print(i, dic[i])
              resultd[i] = dic[i]
            except:
              #print(i, "Unknown Name")
              resultd[i] = "Unknown Name"
    if not worker(name):
      #print("NO")
      resultd["NO"] = ""
    resulta = {}
    for i in out:
      resulta[i[:4]] = i[5:]
    print(index, resulta == resultd)
