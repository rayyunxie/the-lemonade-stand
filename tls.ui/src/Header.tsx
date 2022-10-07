import logo from './assets/logo.svg';
import './Header.css';

export default function Header() {
  return (
    <header className='App-header'>
      <img src={logo} className='App-logo' alt='logo' />
    </header>
  );
}
