import React from 'react';
import WorkoutItem from './WorkoutItem';
import styles from '../styles/WorkoutList.module.css';

const WorkoutList = ({ workouts }) => {
  return (
    <div className={styles.workoutList}>
      {workouts.map((workout) => (
        <WorkoutItem key={workout.id} workout={workout} />
      ))}
    </div>
  );
};

export default WorkoutList;
