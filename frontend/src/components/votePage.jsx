import React, { useState } from 'react';
import { Paper, Typography, RadioGroup, FormControlLabel, Radio, Button, Container, Dialog, DialogTitle, DialogActions } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { submitVote } from "./apiService";


export default function VotePage() {
  const navigate = useNavigate();
  const [selectedOption, setSelectedOption] = useState('');
  const [openDialog, setOpenDialog] = useState(false);

  const handleRadioChange = (event) => {
    setSelectedOption(event.target.value);
  };

  const handleVoteSubmit = async () => {
    try {
      const result = await submitVote(selectedOption); 
      console.log(result);
      setOpenDialog(true);
    } catch (error) {
      console.error("Failed to submit vote:", error);
    }
  };

  const handleDialogClose = () => {
    setOpenDialog(false);
    navigate('/election');
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

      {/* Dialog for Thank You message */}
      <Dialog open={openDialog} onClose={handleDialogClose}>
        <DialogTitle>Thank you for your vote!</DialogTitle>
        <DialogActions>
          <Button onClick={handleDialogClose} color="primary">
            OK
          </Button>
        </DialogActions>
      </Dialog>
    </Container>
  );
}
