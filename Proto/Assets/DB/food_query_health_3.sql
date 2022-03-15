SELECT id, nimi, health, climate
FROM foods
WHERE health > 5 -- 6 ja 7
ORDER BY health, id;