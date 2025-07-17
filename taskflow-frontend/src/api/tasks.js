import axios from 'axios';

const API_URL = import.meta.env.VITE_API_URL || 'http://localhost:5071';

const api = axios.create({
  baseURL: API_URL,
  headers: {
    'Content-Type': 'application/json'
  }
});

// Token ekleme
api.interceptors.request.use(config => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

export const tasksAPI = {
  /**
   * Kullanıcının görevlerini getirir
   * @returns {Promise<Array>} Görev listesi
   */
  getMyTasks: async () => {
    try {
      const response = await api.get('/api/Gorev/me');
      return response.data;
    } catch (error) {
      console.error('Görevler alınırken hata:', error.response?.data);
      throw new Error(error.response?.data?.message || 'Görevler alınamadı');
    }
  },

  /**
   * Yeni görev oluşturur
   * @param {Object} taskData - { baslik, aciklama }
   * @returns {Promise<Object>} Oluşturulan görev
   */
  createTask: async (taskData) => {
    try {
      const response = await api.post('/api/Gorev', {
        baslik: taskData.baslik,
        aciklama: taskData.aciklama,
        tamamlandiMi: false
      });
      return response.data;
    } catch (error) {
      console.error('Görev oluşturma hatası:', error.response?.data);
      throw new Error(
        error.response?.data?.errors?.join(', ') || 
        'Görev oluşturulamadı'
      );
    }
  },

  /**
   * Görevi günceller
   * @param {number} id - Görev ID
   * @param {Object} taskData - Güncellenecek veri
   * @returns {Promise<Object>} Güncellenen görev
   */
  updateTask: async (id, taskData) => {
    try {
      const response = await api.put(`/api/Gorev/${id}`, taskData);
      return response.data;
    } catch (error) {
      console.error('Görev güncelleme hatası:', error.response?.data);
      throw new Error('Görev güncellenemedi');
    }
  },

  /**
   * Görevi siler
   * @param {number} id - Görev ID
   * @returns {Promise<void>}
   */
  deleteTask: async (id) => {
    try {
      await api.delete(`/api/Gorev/${id}`);
    } catch (error) {
      console.error('Görev silme hatası:', error.response?.data);
      throw new Error('Görev silinemedi');
    }
  }
};