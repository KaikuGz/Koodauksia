Oikeat_Numerot = {}
Arvatut_Numerot = {}

MaxLuku = 42
Maara = 7

while #Oikeat_Numerot < Maara do
    local r = math.random(0, MaxLuku)
    local isDuplicate = false
    for index, value in ipairs(Oikeat_Numerot) do
        if value == r then
            isDuplicate = true
            break
        end
    end
    if not isDuplicate then
        table.insert(Oikeat_Numerot, r)
    end
end

print("GIVE UR NUMBERS")
while #Arvatut_Numerot < Maara do
    local s = io.read("*n")
    local isDuplicate = false
    local isTooLarge = false
    if s > MaxLuku then
        print("TOO LARGE NUMBER")
        isTooLarge = true
    else
        for _, value in ipairs(Arvatut_Numerot) do
            if value == s then
                isDuplicate = true
                print("NO DUPLICATES")
                break
            end
        end
    end
    if not isDuplicate and not isTooLarge then
        table.insert(Arvatut_Numerot, s)        
    end
end


local laskin = 0
for _, guessedValue in ipairs(Arvatut_Numerot) do
    for _, correctValue in ipairs(Oikeat_Numerot) do
        if guessedValue == correctValue then
            laskin = laskin + 1
        end
    end
end

print("[ ARVATUT ]")
for index, value in ipairs(Arvatut_Numerot) do
    print("[",Arvatut_Numerot[index],"]")
end

print("[ OIKEAT ]")
for index, value in ipairs(Oikeat_Numerot) do
    print("[",Oikeat_Numerot[index],"]")
end

print("[ SAIT ",laskin," OIKEIN]")