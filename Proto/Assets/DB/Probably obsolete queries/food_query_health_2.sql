SELECT id, nimi, health, climate
FROM foods
WHERE health > 2 AND health < 6 -- 3, 4 ja 5
ORDER BY health, id;