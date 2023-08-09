# EDABIT TEHTÄVIÄ # 

# FIND HIGHEST WITHOUT USING MAX() #

def find_highest(array):
    highest = 0
    for i in range(len(array)):
        if(array[i]>highest):
            highest = array[i]
    return print(highest)

find_highest([-1, 355555,555, 255, 55, 15552, 2555])


# ENCODE TEXT TO MORSE #

def encode_morse(text):
    char_to_dots = {
        'A': '.-', 'B': '-...', 'C': '-.-.', 'D': '-..', 'E': '.', 'F': '..-.',
        'G': '--.', 'H': '....', 'I': '..', 'J': '.---', 'K': '-.-', 'L': '.-..',
        'M': '--', 'N': '-.', 'O': '---', 'P': '.--.', 'Q': '--.-', 'R': '.-.',
        'S': '...', 'T': '-', 'U': '..-', 'V': '...-', 'W': '.--', 'X': '-..-',
        'Y': '-.--', 'Z': '--..', ' ': ' ', '0': '-----',
        '1': '.----', '2': '..---', '3': '...--', '4': '....-', '5': '.....',
        '6': '-....', '7': '--...', '8': '---..', '9': '----.',
        '&': '.-...', "'": '.----.', '@': '.--.-.', ')': '-.--.-', '(': '-.--.',
        ':': '---...', ',': '--..--', '=': '-...-', '!': '-.-.--', '.': '.-.-.-',
        '-': '-....-', '+': '.-.-.', '"': '.-..-.', '?': '..--..', '/': '-..-.'
    }
    x = [*text.upper()]
    result_text = ""
    for i in range(len(x)):
        result_text += char_to_dots[x[i]] + " "
    return print(result_text)

encode_morse("Muuttaa tekstin morsecodeksi")