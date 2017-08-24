import csv

def isNumber(s):
    try:
        float(s)
        return True
    except ValueError:
        return False

def isLongitude(s):
    s=float(s)
    if s>126 and s<128:
        return True
    

lst=[1081, 1082, 444, 445, 448, 449]
with open('C:\\Users\\이민지\\Desktop\\인턴\\의대데이터\\data_utf8.csv', 'r') as csvfile:
    with open('C:\\Users\\이민지\\Desktop\\인턴\\의대데이터\\data.csv', 'w') as csvfile2:
        reader = csv.reader(csvfile)
        writer= csv.writer(csvfile2, lineterminator='\n')
        for row in reader:
            if isNumber(row[1081]) and isNumber(row[1082]) :
                if isLongitude(row[1081]):
                    newrow=[]
                    for i in lst:
                            newrow+=[row[i]]
                    writer.writerow(newrow)


