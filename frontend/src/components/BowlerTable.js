// Table component

import React from "react";

const BowlerTable = ({ bowlers }) => {
  return (
    <table border="1">
      <thead>
        <tr>
          <th>Bowler Name</th>
          <th>Team Name</th>
          <th>Address</th>
          <th>City</th>
          <th>State</th>
          <th>Zip</th>
          <th>Phone Number</th>
        </tr>
      </thead>
      <tbody>
        {bowlers.length > 0 ? (
          bowlers.map((bowler, index) => (
            <tr key={index}>
              <td>{bowler.name}</td>
              <td>{bowler.team}</td>
              <td>{bowler.address}</td>
              <td>{bowler.city}</td>
              <td>{bowler.state}</td>
              <td>{bowler.zip}</td>
              <td>{bowler.phone}</td>
            </tr>
          ))
        ) : (
          <tr>
            <td colSpan="7">Loading...</td>
          </tr>
        )}
      </tbody>
    </table>
  );
};

export default BowlerTable;
