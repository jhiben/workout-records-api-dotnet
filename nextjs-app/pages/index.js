import React, { useEffect, useState, useCallback, useMemo } from 'react';
import WorkoutList from '../components/WorkoutList';

const HomePage = () => {
  const [workouts, setWorkouts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const fetchWorkouts = useCallback(async () => {
    try {
      const response = await fetch('/api/workouts');
      if (!response.ok) {
        throw new Error('Failed to fetch workouts');
      }
      const data = await response.json();
      setWorkouts(data);
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    fetchWorkouts();
  }, [fetchWorkouts]);

  const memoizedWorkouts = useMemo(() => workouts, [workouts]);

  return (
    <div>
      <h1>Workout Records</h1>
      {loading && <p>Loading...</p>}
      {error && <p>Error: {error}</p>}
      {!loading && !error && <WorkoutList workouts={memoizedWorkouts} />}
    </div>
  );
};

export default HomePage;
