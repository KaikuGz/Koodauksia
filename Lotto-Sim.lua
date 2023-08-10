-- Writen By Kaiku
-- Lotto Sim in Lua

Oikeat_Numerot = {}
Arvatut_Numerot = {}

MaxLuku = 42
Maara = 7

-- GENEROI VOITTONUMEROT
while #Oikeat_Numerot < Maara do
    local r = math.random(0, MaxLuku)
    local isDuplicate = false
    for index, value in ipairs(Oikeat_Numerot) do
        if value == r then
            isDuplicate = true
            break
        end
    end
    
    --JOS EI OLE JO LISTASSA NIIN LISÄÄ
    if not isDuplicate then
        table.insert(Oikeat_Numerot, r)
    end
end


print("GIVE UR NUMBERS")
--KYSYY PELAAJAN NUMEROT YKSITELLEN

while #Arvatut_Numerot < Maara do
    local s = io.read("*n")
    local isDuplicate = false
    local isTooLarge = false
    
    -- KATSOO ONKO NUMERO YLI MAX LUVUN
    if s > MaxLuku then        
        print("TOO LARGE NUMBER")
        isTooLarge = true
    else

        -- JOS EI OLE YLI MAX LUVUN KATSOO ONKO JO LISTASSA
        
        for _, value in ipairs(Arvatut_Numerot) do
            if value == s then
                isDuplicate = true
                print("NO DUPLICATES")
                break
            end
        end
    end

    -- LISÄÄ JOS EI OLE LISTASSA
    if not isDuplicate and not isTooLarge then
        table.insert(Arvatut_Numerot, s)        
    end
end

-- LASKEE KUINKA MONTA OIKEAA NUMEROA LÖYTYI
local laskin = 0
for _, guessedValue in ipairs(Arvatut_Numerot) do
    for _, correctValue in ipairs(Oikeat_Numerot) do
        if guessedValue == correctValue then
            laskin = laskin + 1
        end
    end
end

-- PRINTTAA VIELLÄ OMAT NUMEROT JA VOITTO NUMEROT
print("[ ARVATUT ]")
for index, value in ipairs(Arvatut_Numerot) do
    print("[",Arvatut_Numerot[index],"]")
end

print("[ OIKEAT ]")
for index, value in ipairs(Oikeat_Numerot) do
    print("[",Oikeat_Numerot[index],"]")
end

print("[ SAIT ",laskin," OIKEIN]")
