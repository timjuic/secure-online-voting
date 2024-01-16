import React from "react";
import { TextField, Button, Paper, Typography, Container } from "@mui/material";
import { Link, useNavigate } from "react-router-dom";
import { loginUser } from "./apiService";

export default function LoginPage() {
  const navigate = useNavigate();

  const handleSubmit = async (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    try {
      const response = await loginUser({
        email: data.get("email"),
        password: data.get("password"),
      });
      console.log(response.data);
      navigate("/election");
    } catch (error) {
      console.error(error.response ? error.response.data : error.message);
    }
  };

  return (
    <Container component="main" maxWidth="xs">
      <Paper
        elevation={3}
        sx={{
          p: 2,
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          mt: 8,
        }}
      >
        <Typography component="h1" variant="h5">
          Login
        </Typography>
        <form onSubmit={handleSubmit}>
          <TextField
            variant="outlined"
            margin="normal"
            required
            fullWidth
            id="email"
            label="Email Address"
            name="email"
            autoComplete="email"
            autoFocus
          />
          <TextField
            variant="outlined"
            margin="normal"
            required
            fullWidth
            name="password"
            label="Password"
            type="password"
            id="password"
            autoComplete="current-password"
          />
          <Button
            type="submit"
            fullWidth
            variant="contained"
            color="primary"
            sx={{ mt: 3, mb: 2 }}
          >
            Login
          </Button>
          <Typography align="center" variant="body2">
            <Link to="/register">Don't have an account? Register</Link>
          </Typography>
        </form>
      </Paper>
    </Container>
  );
}
