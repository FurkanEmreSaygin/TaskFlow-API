import { Link, useNavigate } from 'react-router-dom';

export default function Navbar() {
  const navigate = useNavigate();
  const isLoggedIn = localStorage.getItem('token');

  const handleLogout = () => {
    localStorage.removeItem('token');
    navigate('/login');
  };

  return (
    <nav className="navbar">
      <div className="navbar-left">
        <Link to="/tasks" className="logo">TaskFlow</Link>
      </div>
      <div className="navbar-right">
        {isLoggedIn ? (
          <button onClick={handleLogout} className="logout-btn">Çıkış Yap</button>
        ) : (
          <>
            <Link to="/login" className="login-btn">Giriş Yap</Link>
            <Link to="/register" className="register-btn">Kayıt Ol</Link>
          </>
        )}
      </div>
    </nav>
  );
}