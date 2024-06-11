![encryption-small](https://github.com/Marcel-TO/Algorithms_and_Datastructure/assets/91308057/cf9c0dfa-0dcc-49ef-bda3-0fe10ca75df3)

# Encryption

## Task


- Implement two substitution cipher algorithms to encrypt and decrypt text in the ISO basic Latin alphabet (A-Z):
    - *Chaociper*
        
        ```
        class Chaocipher:
          lAlphabet: string
          rAlphabet: string
        ```
        
        ```
          fn encrypt(plaintext: string) -> ciphertext: string
          fn decrypt(ciphertext: string) -> plaintext: string
        ```
        
    - *Autokey Cipher* (using a tabula recta)
        
        tabula recta
        
        ```
          fn encrypt(plaintext: string, primer: string) -> ciphertext: string
          fn decrypt(ciphertext: string, primer: string) -> plaintext: string
        
        ```
        
- Prepare comprehensive unit tests
    
    Strive for a unit test coverage of 100% (where sensible.)
    
    ---
    
## Chaocipher
[Full article here!](https://cs.widener.edu/~yanako/html/courses/Fall17/csci391/Chaocipher-Revealed-Algorithm.pdf)
The Chaocipher was invented by J.F.Byrne in 1918 and, although simple by modern cryptographic standards, does not appear to have been broken until the algorithm was finally disclosed by his family in 2010.

## Autokey Cipher
[Full article here!](https://en.wikipedia.org/wiki/Autokey_cipher)
> The autokey cipher, as used by members of the American Cryptogram Association, starts with a relatively-short keyword, the *primer*, and appends the message to it. If, for example, the keyword is `QUEENLY` and the message is `attack at dawn`, the key would be `QUEENLYATTACKATDAWN`.

```
Plaintext:  attackatdawn...
Key:        QUEENLYATTACKATDAWN....
Ciphertext: QNXEPVYTWTWP...
```

![tabula-recta](https://github.com/Marcel-TO/Algorithms_and_Datastructure/assets/91308057/399ef2ef-0ed0-4eb1-a926-617f0c2c2be8)
