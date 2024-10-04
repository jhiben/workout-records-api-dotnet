import React from 'react';

const WorkoutItem = ({ workout }) => {
  return (
    <div>
      <h2>{workout.name}</h2>
      <p>Time Cap: {workout.timeCap}</p>
      <p>Rounds: {workout.roundsCount}</p>
      <ul>
        {workout.movements.map((movement, index) => (
          <li key={index}>
            {movement.name} - {movement.reps} reps
          </li>
        ))}
      </ul>
    </div>
  );
};

export default WorkoutItem;
