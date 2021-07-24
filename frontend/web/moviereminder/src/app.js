import React from "react";
import {
  Typography,
  AppBar,
  Toolbar,
  IconButton,
  Button,
} from "@material-ui/core";
import MenuIcon from "@material-ui/icons/Menu";

function App() {
  return (
    <>
      <AppBar position="fixed">
        <Toolbar>
          <IconButton edge="start" color="inherit" aria-label="menu">
            <MenuIcon />
          </IconButton>
          <Typography variant="h4" align="center">
            Movie Reminder
          </Typography>
          <Button color="inherit">Login/Signup</Button>
        </Toolbar>
      </AppBar>
    </>
  );
}

export default App;
