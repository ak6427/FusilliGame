SELECT id, nimi, health, climate
FROM foods
WHERE health < 3 -- 1 ja 2
ORDER BY health, id;