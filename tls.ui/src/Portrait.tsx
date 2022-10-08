import './Portrait.css';

type Props = {
  imgSrc: string;
  imgAlt: string;
  primaryText: string;
  secondaryText: string;
};

export default function Portrait({
  imgSrc,
  imgAlt,
  primaryText,
  secondaryText,
}: Props) {
  return (
    <div className='Portrait'>
      <img src={imgSrc} alt={imgAlt} />
      <span>{primaryText}</span>
      <span>{secondaryText}</span>
    </div>
  );
}
