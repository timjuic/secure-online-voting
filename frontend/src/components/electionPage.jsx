import React from "react";
import {
  AppBar,
  Toolbar,
  Typography,
  Container,
  Select,
  MenuItem,
  Button,
  FormControl,
  InputLabel,
} from "@mui/material";
import { useNavigate } from "react-router-dom";

export default function ElectionPage() {
  const navigate = useNavigate();

  const [election, setElection] = React.useState("");

  const handleChange = (event) => {
    setElection(event.target.value);
  };

  const handleSubmit = () => {
    console.log(`Election selected: ${election}`);
    navigate("/vote");
  };

  return (
    <>
      <AppBar position="static">
        <Toolbar style={{ justifyContent: "flex-start" }}>
          <Typography
            variant="h6"
            style={{ marginLeft: "30%", paddingRight: "500px" }}
          >
            OVS
          </Typography>
          <Button color="inherit">Elections</Button>
          <Button color="inherit">My Votes</Button>
          <Button color="inherit">Log Out</Button>
        </Toolbar>
      </AppBar>

      <Container
        maxWidth="sm"
        style={{ marginTop: "50px", textAlign: "center" }}
      >
        <Typography variant="h4" gutterBottom>
          Secure online voting system
        </Typography>
        <div style={{ margin: "24px auto", width: "fit-content" }}>
          <Typography variant="h6" gutterBottom>
            Choose Election
          </Typography>
          <FormControl fullWidth>
            <InputLabel id="election-select-label">Elections...</InputLabel>
            <Select
              labelId="election-select-label"
              id="election-select"
              value={election}
              label="Elections"
              onChange={handleChange}
            >
              <MenuItem value="Election 1">Election 1</MenuItem>
              <MenuItem value="Election 2">Election 2</MenuItem>
              <MenuItem value="Election 3">Election 3</MenuItem>
            </Select>
          </FormControl>
          <Button
            variant="contained"
            color="primary"
            style={{ marginTop: "20px" }}
            onClick={handleSubmit}
          >
            Select
          </Button>
        </div>
      </Container>
    </>
  );
}
