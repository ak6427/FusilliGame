PRAGMA foreign_keys = ON;

--DROP TABLE IF EXISTS foods;

CREATE TABLE foods (
    id INT NOT NULL,
    nimi VARCHAR(30) NOT NULL, 
    --name VARCHAR(30) NOT NULL,
    health INT NOT NULL, --terveysvaikutus ranking 1-7
    climate INT NOT NULL, --ilmastovaikutus ranking 1-7
    --season INT NOT NULL, --sesonki 1-6 vuoden ympäri, kesä, syksy, talvi, kevät, kevät+syksy
    PRIMARY KEY (id),
    UNIQUE (nimi)
);