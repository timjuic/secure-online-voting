-- Voters Table
CREATE TABLE Voters (
    voter_id INTEGER PRIMARY KEY,
    name TEXT,
    email TEXT,
    password TEXT,
    registration_date DATETIME
);

-- Candidates Table
CREATE TABLE Candidates (
    candidate_id INTEGER PRIMARY KEY,
    name TEXT,
    party_affiliation TEXT,
    position TEXT
);

-- Elections Table
CREATE TABLE Elections (
    election_id INTEGER PRIMARY KEY,
    title TEXT,
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
    FOREIGN KEY (candidate_id) REFERENCES Candidates(candidate_id),
    FOREIGN KEY (election_id) REFERENCES Elections(election_id)
);


-- Votes Table
CREATE TABLE Votes (
    vote_id INTEGER PRIMARY KEY,
    voter_id INTEGER,
    election_id INTEGER,
    candidate_id INTEGER,
    vote_timestamp DATETIME,
    FOREIGN KEY (voter_id) REFERENCES Voters(voter_id),
    FOREIGN KEY (election_id) REFERENCES Elections(election_id),
    FOREIGN KEY (candidate_id) REFERENCES Candidates(candidate_id)
);