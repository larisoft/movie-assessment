import React from 'react';

const SearchBox = (props) => {
	const handleInputChange = (event) => {
		const searchText = event.target.value;
		props.setSearchValue(searchText);
		props.onTextChange(searchText); // Call the parent component's function
	};

	return (
		<div className='col col-sm-4'>
			<input
				className='form-control'
				value={props.value}
				onChange={handleInputChange}
				placeholder='Search movies'
			></input>
		</div>
	);
};

export default SearchBox;
