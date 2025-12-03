import re

def validate_password(password):
    if len(password) < 8:
        print("Password should have at least 8 characters")
        return False

    if not re.search(r'[A-Z]', password):
        print("Password should contain at least one uppercase letter")
        return False

    if not re.search(r'[a-z]', password):
        print("Password should contain at least one lowercase letter")
        return False

    if not re.search(r'\d', password):
        print("Password should have at least one digit")
        return False

    if not re.search(r'[!@#$%^&*(),.?":{}|<>]', password):
        print("Password should have at least one special character")
        return False

    return True

password = input("Input your password: ")

if validate_password(password):
    print("Valid password")
else:
    print("Invalid password")