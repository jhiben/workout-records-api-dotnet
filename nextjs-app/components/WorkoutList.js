import React from 'react';
import WorkoutItem from './WorkoutItem';

const WorkoutList = ({ workouts }) => {
  return (
    <div>
      {workouts.map((workout) => (
        <WorkoutItem key={workout.id} workout={workout} />
      ))}
    </div>
  );
};

export default WorkoutList;
