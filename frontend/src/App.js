import React, { useEffect, useState } from "react";
import axios from "axios";
import Header from "./components/Header";
import BowlerTable from "./components/BowlerTable";

const API_URL = "http://localhost:5031/api/bowlers"; 

const App = () => {
  const [bowlers, setBowlers] = useState([]);

  useEffect(() => {
    axios
      .get(API_URL)
      .then((response) => {
        console.log("API Response:", response.data);
        setBowlers(response.data);
      })
      .catch((error) => {
        console.error("Error fetching bowlers:", error);
      });
  }, []);
  

  // display header and table
  return (
    <div>
      <Header />
      <BowlerTable bowlers={bowlers} />
    </div>
  );
};

export default App;
