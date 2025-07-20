import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { tasksAPI } from '../api/tasks';
import AddTask from './AddTask';
import TaskCard from '../components/TaskCard';

export default function Tasks() {
  const [tasks, setTasks] = useState([]);
  const [showAddModal, setShowAddModal] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    if (!localStorage.getItem('token')) {
      navigate('/login');
      return;
    }
    fetchTasks();
  }, []);

const fetchTasks = async () => {
  try {
    const data = await tasksAPI.getMyTasks(); // Artık bu fonksiyon tanımlı
    setTasks(data);
  } catch (error) {
    console.error('Hata:', error.message);
  }
};

  return (
    <div className="tasks-page">
      <h1>Görevlerim</h1>
      <button onClick={() => setShowAddModal(true)} className="add-task-btn">
        + Yeni Görev
      </button>
      
      <div className="task-list">
        {tasks.map(task => (
          <TaskCard key={task.id} task={task} onUpdate={fetchTasks} />
        ))}
      </div>

      {showAddModal && (
        <AddTask 
          onClose={() => setShowAddModal(false)} 
          onTaskAdded={fetchTasks}
        />
      )}
    </div>
  );
}