import React, { useEffect, useState } from 'react';
import WorkoutList from '../components/WorkoutList';

const HomePage = () => {
  const [workouts, setWorkouts] = useState([]);

  useEffect(() => {
    const fetchWorkouts = async () => {
      const response = await fetch('/api/workouts');
      const data = await response.json();
      setWorkouts(data);
    };

    fetchWorkouts();
  }, []);

  return (
    <div>
      <h1>Workout Records</h1>
      <WorkoutList workouts={workouts} />
    </div>
  );
};

export default HomePage;
