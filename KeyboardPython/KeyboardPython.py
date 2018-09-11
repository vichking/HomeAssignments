# example string - inside the 4X10 matrix
# example transformations = H (horizontal), V(vertical), N (right shift by N positions), -N (left shift by N positions)
# I calculated post-transformation coordinates for each letter


def horizontal_flip(coord):
    return (coord[0], mat_length-1-coord[1])

def vertical_flip(coord):
    return (mat_height -1- int(coord[0]), coord[1])
            
def right_shift(coord, num):
    return (coord[0], (coord[1]+num)%mat_length)

def left_shift(coord, num):
    num = num%10
    return (coord[0], (mat_length+coord[1]-num)%mat_length)

def transform_char(c, transform_string):
    coord = coordinates_map[c.lower()]
    flips = transform_string.split(' ')
    for f in flips:
        f= f.upper()
        if f=="H": 
            coord = horizontal_flip(coord)
        elif f=="V": 
            coord= vertical_flip(coord)
        elif "-" in f: 
            coord= left_shift(coord, abs(int(f)))
        else: 
            coord = right_shift(coord, int(f))  
    if c.isupper():
        return (matrix[coord[0]][coord[1]]).upper()
    else:
        return matrix[coord[0]][coord[1]]
            
def transform(str, transform_string):
    result=""
    chars_done = dict()  # I don't want to convert the same letter twice
    for i in range(len(str)):
        if str[i] in chars_done.keys():
            result+= chars_done[str[i]]
        else:
            transformed_char = transform_char(str[i], transform_string) 
            chars_done[str[i]] = transformed_char
            result += transformed_char
    return result



# create initial keyboard          
arr1 = [ '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' ]
arr2= ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' ]
arr3 = [ 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', ';' ]
arr4 = ['z', 'x', 'c', 'v', 'b', 'n', 'm', ',', '.', '/' ]
matrix = [arr1, arr2, arr3, arr4]   

# create initial keyboard map (get coordinates by symbol)
coordinates_map = dict()
mat_length = len(matrix[0])
mat_height = len(matrix)
for i in range(mat_height):
    for j in range (mat_length):
        coordinates_map[matrix[i][j]] = (i, j)


# the action is here
original_string = input("\nInput original string : ")
transformation = input("\nInput transformation pattern in 'H V 5 -5' format:  ")
print("\nOriginal string: ", original_string)
print("\nTransformation: ", transformation)
print("\nResult: ", transform(original_string, transformation), "\n\n")

