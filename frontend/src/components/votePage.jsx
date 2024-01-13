import React from 'react';
import { Paper, Typography, RadioGroup, FormControlLabel, Radio, Button, Container } from '@mui/material';


export default function VotePage() {
    const [selectedOption, setSelectedOption] = React.useState('');

  const handleRadioChange = (event) => {
    setSelectedOption(event.target.value);
  };

  const handleVoteSubmit = () => {
    console.log(`Voted for: ${selectedOption}`);

  };

  return (
    <Container component="main" maxWidth="xs">
      <Paper elevation={3} sx={{ p: 2, mt: 8, display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
        <Typography variant="h5" sx={{ mb: 2 }}>
          Election Name 1
        </Typography>
        <RadioGroup name="electionOptions" value={selectedOption} onChange={handleRadioChange}>
          <FormControlLabel value="Option 1" control={<Radio />} label="Option 1" />
          <FormControlLabel value="Option 2" control={<Radio />} label="Option 2" />
          <FormControlLabel value="Option 3" control={<Radio />} label="Option 3" />
          <FormControlLabel value="Option 4" control={<Radio />} label="Option 4" />
        </RadioGroup>
        <Button
          variant="contained"
          color="primary"
          sx={{ mt: 3 }}
          onClick={handleVoteSubmit}
        >
          Vote
        </Button>
      </Paper>
    </Container>
  );
}
