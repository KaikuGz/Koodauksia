#- KIRJOITTANUT HERRA KADDI -#
import random
import time
import os

maara = 43
arvattavamaara = 7
arvatutnumerot = []
oikeatnumerot = []

laskin = 1
oikeinmenneet = 0

# RETURNAA FALSE JOS ON SAMA NUMERO KUN MIKÄ ON LISTASSA JO JA KATSOO ONKO NUMERO LIIAN ISO TAI LIIAN PIENI# 2
def testaus(arvattu):
    if arvattu in arvatutnumerot:
        print("[ EI SAMOJA! ]")
        return False
    if arvattu<maara and arvattu>-1:
        sopiva = True
        return True
    if arvattu-1 and sopiva==True:
        print("[ ONNISTUI! ]")
        return True

# KYSYY NUMEROITA NIIN KAUAN ETTÄ SAAT 7 VALID NUMEROA LISTAAN # 1
while len(arvatutnumerot)<arvattavamaara:
    try:
        print(f"ARVAA NUMERO [{laskin}]")
        arvattunumero = int(input(""))
        x = testaus(arvattunumero)
        if x==True:
            arvatutnumerot.append(arvattunumero)
            laskin+=1
    except:
        print("[ VIRHE! ]")
        continue

# GENEROI VALID NUMEROT RANDOMILLA JOTTA SAADAAN VOITTONUMEROT # 3
while len(oikeatnumerot)<arvattavamaara:
    generoidut = oikeatnumerot.append(random.randint(0,maara))
    if generoidut not in oikeatnumerot and generoidut!=None:
        oikeatnumerot.append(generoidut)
    else:
        continue

# LASKEE KUINKA MONTA ARVAUSTA MENI OIKEIN # 4
for i in range(len(arvatutnumerot)):
    if(arvatutnumerot[i] in oikeatnumerot):
        oikeinmenneet+=1


print("ARVOTAAN NUMEROT")
for i in range(len(oikeatnumerot)):
    print(f"[ SINUN LAPPU ]")
    print(arvatutnumerot)

    print(oikeatnumerot[i])
    time.sleep(0.25)
    os.system('cls')

print(f"[ SINUN LAPPU {arvatutnumerot}]")
print(f"[   JACKPOT   {oikeatnumerot}]")
print(f"[ SAIT {oikeinmenneet} NUMEROA OIKEIN! ]")
quit()