prg1:

import hashlib
def hash_password(password):
    password_bytes=password.encode('utf-8')
    hash_object=hashlib.sha256(password_bytes)
    password_hash=hash_object.hexdigest()
    return password_hash
password=input("input your password:")
hashed_password=hash_password(password)
print(f"your hashed password is:{hashed_password}")

output;
input your password:hello
your hashed password is:2cf24dba5fb0a30e26e83b2ac5b9e29e1b161e5c1fa7425e73043362938b9824

prg2:

import random
import string
def generate_password(length=8):
 characters = string.ascii_letters + string.digits + string.punctuation
 password = ''.join(random.choice(characters) for i in range(length))
 return password
password_length = int(input("Input the desired length of your password:")or 8)
password = generate_password(password_length)
print("Generated password is:", password)

output:
Input the desired length of your password:8
Generated password is: nP6kUc,3

prg3:

import re


def validate_password(password):
    if len(password) < 8:
        print("Password Should have atleast 8 characters")
        return False
    if not re.search(r'[A-Z]', password):
        print("Password should have atleast one uppercase letter")
        return False
    if not re.search(r'[a-z]', password):
        print("Password should contain atleast one lowercase letter")
        return False
    if not re.search(r'\d', password):
        print("password should have atleast one digit")
        return False
    if not re.search(r'[!@#$%^&*(),.?":{}|<>]', password):
        print("Password should have atleast one special character")
        return False
    return True


password = input("Input your password: ")
if validate_password(password):
    print("Valid Password.")
else:
    print("Password does not meet requirements.")

output:
Input your password: Sadik@123
Valid Password.

Input your password: sadikmbb
Password should have atleast one uppercase letter
Password does not meet requirements.

prg4:

import re
def check_password(password):
 length_regex = re.compile(r'^.{8,}$')
 uppercase_regex = re.compile(r'[A-Z]')
 lowercase_regex = re.compile(r'[a-z]')
 digit_regex = re.compile(r'\d')
 special_regex = re.compile(r'[\W_]')
 length_check = length_regex.search(password)
 uppercase_check = uppercase_regex.search(password)
 lowercase_check = lowercase_regex.search(password)
 digit_check = digit_regex.search(password)
 special_check = special_regex.search(password)
 if length_check and uppercase_check and lowercase_check and digit_check and special_check:
   return True
 else:
   return False
with open(r'D:\cslabprg\prg4') as f:
 for password in f:
   password = password.strip() # Remove newline character
   if check_password(password):
      print("Valid Password: "+password)
   else:
      print("Invalid: " + password)

create a text file:
Sangeeta
Sanjay@123
Sanjay23
Sanjay@

output:
Invalid: Sangeeta
Valid Password: Sanjay@123
Invalid: Sanjay23
Invalid: Sanjay@

prg5:

import re
def check_password_strength(password):
    score = 0
    suggestions = []
    if len(password) >= 8:
       score += 1
    else:
       suggestions.append("Password should be at least 8 characters long")
    if re.search(r"[A-Z]", password):
      score += 1
    else:
      suggestions.append("Password should contain at least one uppercase letter")
    if re.search(r"[a-z]", password):
      score += 1
    else:
      suggestions.append("Password should contain at least one lowercase letter")
    if re.search(r"\d", password):
      score += 1
    else:
       suggestions.append("Password should contain at least one numeric digit")
    if re.search(r"[!_@#$%^&*/(),.?\":{}|<>]", password):
       score += 1
    else:
      suggestions.append("Password should contain at least one special character (!@#$%^&*(),.?\":{}|<>)")
    return score, suggestions
password = input("Input a password: ")
score, suggestions=check_password_strength(password)
print(score)
print(f"Password Score:{score}/5")
if suggestions:
    print("\n Suggestions to improve your password:")
    for suggestion in suggestions:
        print(f"-{suggestion}")
else:
    print("\n your password meets all criteria!")

output:

Input a password: Sadik1
3
Password Score:3/5
 
 Suggestions to improve your password:
-Password should be at least 8 characters long
-Password should contain at least one special character (!@#$%^&*(),.?":{}|<>)
 

Input a password: Sadik@123
5
Password Score:5/5
 
 your password meets all criteria!
 

prg6:

 

import requests
import hashlib
with open(r'D:\cslabprg\prg6') as f:
    for line in f:
        username, password = line.strip().split(',')
        password_hash = hashlib.sha1(password.encode('utf-8')).hexdigest().upper()
        response = requests.get(f"https://api.pwnedpasswords.com/range/{password_hash[:5]}")
        if response.status_code == 200:
            hashes = [line.split(':') for line in response.text.splitlines()]
            for h, count in hashes:
                if password_hash[5:] == h:
                    print(f"Password for {username} has been leaked {count} times.")
                    break
        else:
            print(f"Could not check password for user {username}.")

create a text file:
alice,1
bob,1234
user1,pas1
user2,password
user3,password123
user4,password123$
download requests package...!!!

output:
Password for alice has been leaked 3453992 times.
Password for bob has been leaked 28926731 times.
Password for user1 has been leaked 1126 times.
Password for user2 has been leaked 46658894 times.
Password for user3 has been leaked 2031380 times.
Password for user4 has been leaked 15259 times.

prg7:

import itertools
import string
def bruteforce_attack(password):
    chars = string.printable.strip()
    attempts = 0
    for length in range(1, len(password) + 1):
        for guess in itertools.product(chars, repeat=length):
            attempts += 1
            guess = ''.join(guess)
            if guess == password:
                return (attempts, guess)
    return (attempts, None)
password = input("Input the password to crack: ")
attempts, guess = bruteforce_attack(password)
if guess:
    print(f"Password cracked in {attempts} attempts. The password is {guess}.")
else:
    print(f"Password not cracked after {attempts} attempts.")


output:

Input the password to crack: abc
Password cracked in 98337 attempts. The password is abc.

prg8:

def encrypt(text, s):
    result = ""
    for i in range(len(text)):
        char = text[i]
        if char.isupper():
            result += chr((ord(char) + s - 65) % 26 + 65)
        # Encrypt lowercase characters
        else:
            result += chr((ord(char) + s - 97) % 26 + 97)
    return result
text = input("Enter the text: ")
s = int(input("Enter the shift between 1 to 25: "))
print("Text: " + text)
print("Shift: " + str(s))
print("Cipher: " + encrypt(text, s))



output:

Enter the text: Sadik
Enter the shift between 1 to 25: 5
Text: Sadik
Shift: 5
Cipher: Xfinp

prg9:

message = 'GMTLIVrHIQS'  # encrypted message
LETTERS = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
for key in range(len(LETTERS)):
    translated = ''
    for symbol in message:
        if symbol in LETTERS:
            num = LETTERS.find(symbol)
            num = num - key
            if num < 0:
                num = num + len(LETTERS)
            translated = translated + LETTERS[num]
        else:
            translated = translated + symbol
    print('Hacking key #%s: %s' % (key, translated))


output:

Hacking key #0: GMTLIVrHIQS
Hacking key #1: FLSKHUrGHPR
Hacking key #2: EKRJGTrFGOQ
Hacking key #3: DJQIFSrEFNP
Hacking key #4: CIPHERrDEMO
Hacking key #5: BHOGDQrCDLN
Hacking key #6: AGNFCPrBCKM
Hacking key #7: ZFMEBOrABJL
Hacking key #8: YELDANrZAIK
Hacking key #9: XDKCZMrYZHJ
Hacking key #10: WCJBYLrXYGI
Hacking key #11: VBIAXKrWXFH
Hacking key #12: UAHZWJrVWEG
Hacking key #13: TZGYVIrUVDF
Hacking key #14: SYFXUHrTUCE
Hacking key #15: RXEWTGrSTBD
Hacking key #16: QWDVSFrRSAC
Hacking key #17: PVCURErQRZB
Hacking key #18: OUBTQDrPQYA
Hacking key #19: NTASPCrOPXZ
Hacking key #20: MSZROBrNOWY
Hacking key #21: LRYQNArMNVX
Hacking key #22: KQXPMZrLMUW
Hacking key #23: JPWOLYrKLTV
Hacking key #24: IOVNKXrJKSU
Hacking key #25: HNUMJWrIJRT

prg10:
download rsa package....!!
import rsa
def rsa_algo( password) :
   publickey, privatekey= rsa.newkeys(512)
   print("Public key: ",publickey)
   print("Private key:",privatekey)
   message = password.encode ('utf-8')
   ciphertext = rsa.encrypt (message, publickey)
   print("cipher text!", ciphertext)
   decrypted_message= rsa.decrypt (ciphertext , privatekey)
   print("decrypted message", decrypted_message.decode('utf -8'))
password = input ("Input your text")
rsa_algo(password)

output:

Input your textSadik
Public key:  PublicKey(8272152408210887667009793859453377392341627805101006495427111583129550030182852811673243928783135627040104726597037080372929323965706369790366085472724373, 65537)
Private key: PrivateKey(8272152408210887667009793859453377392341627805101006495427111583129550030182852811673243928783135627040104726597037080372929323965706369790366085472724373, 65537, 2434173965734576936055722333636852205796852041158016239136851654495222122421737142542970132545059426836597767574106530842401810991581658677104938282062273, 4922111969399497259174015767708821700924613758469047014863086387645553972354264881, 1680610367996179249707735818334895724713398125179607943528196798615399333)
cipher text! b'1\xe6\x19r\x97\xa6*h\x1a\x13\xfcoD4\xe98\x0c\x1c\x9e\xdd\xf15m(\x8d\xb6<\xaf\xf5l\x08\xc7\xed\xc0\x92\x80\xd8\xc3\x93\n"\xa1\xec\xc8\xccR\xaa\x84\x8b\xb0U\xaaR\xa5\xc9\xfc\xb0 c\xdfI>\xc2\xad'
decrypted message Sadik

prg11:

import base64
my_string = "Hello, World!"
encoded_string = base64.b64encode(my_string.encode("utf-8"))
print("encoded string:",encoded_string)
my_string = "SGVsbG8sIFdvcmxkIQ=="
decoded_string = base64.b64decode(my_string)
print("decoded string:",decoded_string.decode("utf-8"))

output:

encoded string: b'SGVsbG8sIFdvcmxkIQ=='
decoded string: Hello, World!

prg12:

from cryptography.fernet import Fernet
key=Fernet.generate_key()
fernet = Fernet(key)
msg=input("Enter the Message: ").encode()
encrypted_msg=fernet.encrypt(msg)
decrypted_msg=fernet.decrypt(encrypted_msg)
decrypted_msg=decrypted_msg.decode()
print("Original Message: ", msg.decode())
print("Encrypted Message: ", encrypted_msg)
print("Decrypted Message: ", decrypted_msg)

download cryptography package..!!

output:

Enter the Message: hii
Original Message:  hii
Encrypted Message:  b'gAAAAABpJt5ijkd9yxdOn4mmBxdAk6ZtbXa11Boy6tLcq12JB8SKI8nbSn6f_IwtWFEcDe5vq8USUO3CeKXTQCfVSXqGbbqjeg=='
Decrypted Message:  hii






