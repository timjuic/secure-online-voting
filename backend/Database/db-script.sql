-- Voters Table
CREATE TABLE Voters (
    voter_id INTEGER PRIMARY KEY,
    first_name TEXT,
    last_name TEXT,
    email TEXT UNIQUE,
    password TEXT,
    registration_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    is_admin INTEGER DEFAULT 0
);

-- Candidates Table
CREATE TABLE Candidates (
    candidate_id INTEGER PRIMARY KEY,
    name TEXT UNIQUE,
    party_affiliation TEXT,
    position TEXT
);

-- Elections Table
CREATE TABLE Elections (
    election_id INTEGER PRIMARY KEY,
    title TEXT UNIQUE,
    description TEXT,
    start_date DATETIME,
    end_date DATETIME,
    is_active INTEGER
);

-- CandidateElections Table
CREATE TABLE CandidateElections (
    candidate_id INTEGER,
    election_id INTEGER,
    PRIMARY KEY (candidate_id, election_id),
    FOREIGN KEY (candidate_id) REFERENCES Candidates(candidate_id) ON DELETE CASCADE,
    FOREIGN KEY (election_id) REFERENCES Elections(election_id) ON DELETE CASCADE
);

-- Votes Table
CREATE TABLE Votes (
    vote_id INTEGER PRIMARY KEY,
    voter_id INTEGER,
    election_id INTEGER,
    candidate_id INTEGER,
    vote_timestamp DATETIME,
    FOREIGN KEY (voter_id) REFERENCES Voters(voter_id) ON DELETE CASCADE,
    FOREIGN KEY (election_id) REFERENCES Elections(election_id) ON DELETE CASCADE,
    FOREIGN KEY (candidate_id) REFERENCES Candidates(candidate_id) ON DELETE CASCADE
);


-- Sample data for Voters Table
INSERT INTO Voters (first_name, last_name, email, password, registration_date, is_admin)
VALUES 
    ('John', 'Doe', 'john.doe@email.com', 'password123', '2022-01-01', 0),
    ('Jane', 'Smith', 'jane.smith@email.com', 'securepass', '2022-01-02', 1),
    ('Bob', 'Johnson', 'bob.johnson@email.com', 'bobpassword', '2022-01-03', 0);

-- Sample data for Candidates Table
INSERT INTO Candidates (name, party_affiliation, position)
VALUES 
    ('Candidate A', 'Party 1', 'President'),
    ('Candidate B', 'Party 2', 'Senator'),
    ('Candidate C', 'Party 3', 'Governor');

-- Sample data for Elections Table
INSERT INTO Elections (title, description, start_date, end_date, is_active)
VALUES 
    ('Presidential Election', 'Electing the President', '2022-02-01', '2022-02-15', 1),
    ('Senate Election', 'Electing Senators', '2022-03-01', '2022-03-15', 0);

-- Sample data for CandidateElections Table
INSERT INTO CandidateElections (candidate_id, election_id)
VALUES 
    (1, 1),
    (2, 1),
    (3, 2);

-- Sample data for Votes Table
INSERT INTO Votes (voter_id, election_id, candidate_id, vote_timestamp)
VALUES 
    (1, 1, 1, '2022-02-05 12:00:00'),
    (2, 1, 2, '2022-02-10 14:30:00'),
    (3, 2, 3, '2022-03-05 10:00:00');
